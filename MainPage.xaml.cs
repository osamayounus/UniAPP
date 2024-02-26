using UniAPP.Code;
using UniAPP.Models;

namespace UniAPP
{
    public partial class MainPage : ContentPage
    {

        private List<Uniobject> uniobjects;
        private HttpHelper httpHelper;
        public MainPage()
        {
            InitializeComponent();
            uniobjects = new List<Uniobject>();
            httpHelper = new HttpHelper();
        }

        private void BtnS_Clicked(object sender, EventArgs e)
        {
            if(Cname.Text!= null)
            {
                LoadData(Cname.Text);
            }
            
        }
        private async void LoadData(string ContryName)
        {
            // Clear
            uniobjects.Clear();
            Unicon.Clear();

            // Get Respones
            InLoading.IsRunning = true;
            InLoading.IsVisible= true;
            var respone = await httpHelper.GetResponeAsync($"http://universities.hipolabs.com/search?country={ContryName}");
            uniobjects = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Uniobject>>(respone);
            //ForLoop into UniObjects
            for(int i = 0; i < uniobjects.Count; i++)
            {
                var item = uniobjects[i];
                Unicon.Add(new Views.UniViews(item.name, item.web_pages[0]));
            }
            InLoading.IsRunning = false;
            InLoading.IsVisible = false;
        }
    }

}
