using log4net;
using SeeHibernateSharp.Libraries.Logging;
using System.Windows;

namespace SeeHibernateSharp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Test
            ILog log = LogManager.GetLogger("hibernating");
            ILogger nlogAdapter = new Log4NetAdapter(log);

            var hibernateOutput = Hibernate.TestApp.Main();

            log.Debug(hibernateOutput);            
        }
    }
}
