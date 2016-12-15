using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace BlocoDeAnotacoes
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class NotaEdicao : Page
    {
        private Nota nota;

        public NotaEdicao()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (e.Parameter != null)
            {
                this.nota = e.Parameter as Nota;
                CarregarNota();
            }
            else
            {
                this.nota = new Nota();
            }
        }

        private void CarregarNota()
        {
            txtTitulo.Text = this.nota.Titulo;
            txtDescricao.Text = this.nota.Descricao;
            tglPrioridade.IsChecked = this.nota.Prioridade;
        }

        private void appBarBtnSalvar_Click(object sender, RoutedEventArgs e)
        {
            SalvarNota();
        }

        private async void SalvarNota()
        {
            this.nota.Titulo = txtTitulo.Text;
            this.nota.Descricao = txtDescricao.Text;
            this.nota.Prioridade = tglPrioridade.IsChecked.HasValue ? tglPrioridade.IsChecked.Value : false;

            NotaDAO.Salvar(nota);

            Frame.Navigate(typeof(MainPage));
        }

        private void appBarBtnExcluir_Click(object sender, RoutedEventArgs e)
        {
            NotaDAO.Remover(nota);
            Frame.Navigate(typeof(MainPage));
        }

        #region Editor

        /*private void BoldButton_Click(object sender, RoutedEventArgs e)
        {
            Windows.UI.Text.ITextSelection selectedText = richEditor.Document.Selection;
            if (selectedText != null)
            {
                Windows.UI.Text.ITextCharacterFormat charFormatting = selectedText.CharacterFormat;
                charFormatting.Bold = Windows.UI.Text.FormatEffect.Toggle;
                selectedText.CharacterFormat = charFormatting;
            }
        }

        private void ItalicButton_Click(object sender, RoutedEventArgs e)
        {
            Windows.UI.Text.ITextSelection selectedText = richEditor.Document.Selection;
            if (selectedText != null)
            {
                Windows.UI.Text.ITextCharacterFormat charFormatting = selectedText.CharacterFormat;
                charFormatting.Italic = Windows.UI.Text.FormatEffect.Toggle;
                selectedText.CharacterFormat = charFormatting;
            }
        }

        private void UnderlineButton_Click(object sender, RoutedEventArgs e)
        {
            Windows.UI.Text.ITextSelection selectedText = richEditor.Document.Selection;
            if (selectedText != null)
            {
                Windows.UI.Text.ITextCharacterFormat charFormatting = selectedText.CharacterFormat;
                if (charFormatting.Underline == Windows.UI.Text.UnderlineType.None)
                {
                    charFormatting.Underline = Windows.UI.Text.UnderlineType.Single;
                }
                else
                {
                    charFormatting.Underline = Windows.UI.Text.UnderlineType.None;
                }
                selectedText.CharacterFormat = charFormatting;
            }
        }*/

        #endregion
    }
}
