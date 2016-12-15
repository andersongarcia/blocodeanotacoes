using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace BlocoDeAnotacoes
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            Listar();
        }

        private void Listar()
        {
            List<Nota> notas = NotaDAO.Buscar(string.Empty);
            lstNotas.DataContext = notas;
        }
        
        private void lstNotas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Nota nota = lstNotas.SelectedItem as Nota;

            Frame.Navigate(typeof(NotaEdicao), nota);
        }

        private void txtBusca_TextChanged(object sender, TextChangedEventArgs e)
        {
            appBarBtnBuscar_Click(sender, e);
        }

        private void lstNotas_DragLeave(object sender, DragEventArgs e)
        {
            Nota nota = lstNotas.SelectedItem as Nota;

            NotaDAO.Remover(nota);
        }
        
        private void appBarBtnBuscar_Click(object sender, RoutedEventArgs e)
        {
            List<Nota> notas = NotaDAO.Buscar(txtBusca.Text);
            lstNotas.DataContext = notas;

        }

        private void appBarBtnAdicionar_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(NotaEdicao), null);
        }
    }
}
