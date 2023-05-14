using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Threading;

namespace ViewModel {
    //Kolekcja obiektow reagujaca na swoja zmiane, dziedziczy po
    //klasie "ObservableCollection"
    public class ObservableBallCollection<T> : ObservableCollection<T> {
        private SynchronizationContext _context = SynchronizationContext.Current;

        public ObservableBallCollection() { 
        
        }

        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e) {
            if (SynchronizationContext.Current != _context) {
                _context.Send(RaiseCollectionChanged, e);
            } else {
                RaiseCollectionChanged(e);
            }
        }

        private void RaiseCollectionChanged(object param) {
            base.OnCollectionChanged((NotifyCollectionChangedEventArgs)param);
        }

        protected override void OnPropertyChanged(PropertyChangedEventArgs e) {
            if (SynchronizationContext.Current != _context) {
                _context.Send(RaisePropertyChanged, e);
            } else {
                RaisePropertyChanged(e);
            }
        }

        private void RaisePropertyChanged(object param) {
            base.OnPropertyChanged((PropertyChangedEventArgs)param);
        }
    }
}
