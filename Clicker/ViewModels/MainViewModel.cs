using Clicker.Models;

using System.ComponentModel;
using System.Windows.Input;

namespace Clicker.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private PlayerModel player;

        public ICommand ClickCommand { get; }

        public MainViewModel()
        {
            player = new PlayerModel();
            ClickCommand = new RelayCommand(Click);
        }

        public PlayerModel Player
        {
            get { return player; }
            set
            {
                if (player != value)
                {
                    player = value;
                    OnPropertyChanged(nameof(Player));
                }
            }
        }

        private void Click()
        {
            Player.Score++;
        }

        // Реализация интерфейса INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
