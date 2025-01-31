using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using Zivver.App.DTO;
using Zivver.App.Extension;
using Zivver.Repository.Model;
using Zivver.Service.Interface;

namespace Zivver.App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Properties
        public ObservableCollection<PostDTO> Posts { get; set; }
        public bool IsShowingId { get; set; } = true;
        public double SquareSize { get; set; }

        // Services
        private readonly IPostService _postService;

        public MainWindow()
        {

        }

        public MainWindow(IPostService postService)
        {
            InitializeComponent();

            _postService = postService;
            Posts = new ObservableCollection<PostDTO>();

            
            DataContext = this;

            // Register events
            this.Loaded += MainWindow_Loaded;
            this.SizeChanged += (s, e) =>
            {
                CalculateSquareSize();
                PostsData.Items.Refresh();
            };
        }

        /// <summary>
        /// Sets posts when a window is loaded
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                foreach (var post in (await LoadPosts())
                         .Select(post => post.ToDTO()))
                {
                    Posts.Add(post);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        /// <summary>
        /// Calculates a square size whenever a window is resized
        /// </summary>
        private void CalculateSquareSize()
        {
            SquareSize = this.ActualWidth / 10;
        }

        private async Task<IEnumerable<Post>> LoadPosts()
        {
            return await _postService.GetPosts();
        }

        private void ToggleDisplay(object sender, MouseButtonEventArgs e)
        {
            IsShowingId = !IsShowingId;
            PostsData.Items.Refresh();
        }
    }

    public class DisplayProperIdConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
		{
			var info = values.ToPostToupleConvertValue();
			if (!info.HasValue)
				return DependencyProperty.UnsetValue;


			var (isShowingId, post) = info.GetValueOrDefault();

			if(post is null)
				return DependencyProperty.UnsetValue;

			return isShowingId
				? post.DisplayId()
				: post.DisplayUserId();
		}

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}