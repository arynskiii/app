namespace Roadmap.Domain
{
    public class SubStage
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid StageId { get; set; }  
        public Stage Stage { get; set; }    
        public List<SubStageUser> SubStageUsers { get; set; }
        

        public SubStage()
        {   
            SubStageUsers = new List<SubStageUser>();
        }
    }
}