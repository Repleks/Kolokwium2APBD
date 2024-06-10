using Microsoft.EntityFrameworkCore;
using Przykladowe1CodeFirst.Context;
using Przykladowe1CodeFirst.Exceptions;

namespace Przykladowe1CodeFirst.Services;

public interface IStudentsService
{
    Task<bool> DeleteStudent(int id);   
}
public class StudentsService(DatabaseContext context) : IStudentsService
{
    public async Task<bool> DeleteStudent(int id)
    {
        var result = false;
        if (id < 1)
        {
            throw new ArgumentException("Your argument is invalid");
        }

        using var transaction = await context.Database.BeginTransactionAsync();
        try
        {
            var student = await context.Students
                .Include(s => s.GroupAssignments)
                .FirstOrDefaultAsync(s => s.StudentId == id);
            if (student == null)
            {
                throw new NotFoundException($"Student with id {id} not found");
            }

            context.GroupAssignments.RemoveRange(student.GroupAssignments);
            context.Students.Remove(student);
            await context.SaveChangesAsync();
            await transaction.CommitAsync();
            result = true;
        }
        catch (Exception)
        {
            await transaction.RollbackAsync();
            throw;
        }
        
        return result;
    }
}