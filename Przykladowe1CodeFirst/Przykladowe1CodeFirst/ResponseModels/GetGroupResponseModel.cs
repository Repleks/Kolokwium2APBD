namespace Przykladowe1CodeFirst.ResponseModels;

public class GetGroupResponseModel
{
    public int GroupId { get; set; }
    
    public string Name { get; set; }
    
    public IEnumerable<int> StudentIds { get; set; }
}