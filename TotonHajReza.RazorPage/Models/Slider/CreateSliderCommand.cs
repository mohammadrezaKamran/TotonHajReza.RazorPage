
namespace TotonHajReza.RazorPage.Models.Slider
{
    public class CreateSliderCommand
    {
        public string Title {  get; set; }
        public string Link {  get; set; }
        public IFormFile ImageFile { get; set; }
   
    }
    public class SliderDto:BaseDto
    {
        public string Title { get; set; }
        public string Link { get; set; }
        public string ImageName { get; set; }
    }
    public class EditSliderCommand
    {
        public long Id {  get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
        public IFormFile? ImageFile { get; set; }

    }
}
