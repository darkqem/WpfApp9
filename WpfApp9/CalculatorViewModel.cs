using ReactiveUI;
using System.Reactive;
using System.Reactive.Linq;

namespace WpfApp9
{
    public class CalculatorViewModel : ReactiveObject
    {
        private int _number1;
        public int Number1
        {
            get => _number1;
            set => this.RaiseAndSetIfChanged(ref _number1, value);
        }

        private int _number2;
        public int Number2
        {
            get => _number2;
            set => this.RaiseAndSetIfChanged(ref _number2, value);
        }

        private readonly ObservableAsPropertyHelper<int> _sum;
        public int Sum => _sum.Value;

        public CalculatorViewModel()
        {
            _sum = this.WhenAnyValue(x => x.Number1, x => x.Number2)
                .Select(x => x.Item1 + x.Item2)
                .ToProperty(this, x => x.Sum);
        }
    }
}
