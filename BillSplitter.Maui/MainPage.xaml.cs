namespace BillSplitter.Maui
{
    public partial class MainPage : ContentPage
    {
        decimal bill;
        int tip;
        int noPersons = 1;

        public MainPage()
        {
            InitializeComponent();
        }


        private void entryBill_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (decimal.TryParse(entryBill.Text, out bill))
                CalculateTotal();
        }

        private void sliderTip_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            SetTip((int)e.NewValue);
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (sender is Button)
            {
                var buton = (Button)sender;
                var percentage = int.Parse(
                    buton.Text.Replace("%", ""));
                sliderTip.Value = percentage;
            }
        }

        private void buttonMinus_Clicked(object sender, EventArgs e)
        {
            if (noPersons > 1)
            {
                noPersons--;
            }
            labelNoPersons.Text = noPersons.ToString();
            CalculateTotal();
        }

        private void buttonPlus_Clicked(object sender, EventArgs e)
        {
            noPersons++;
            labelNoPersons.Text = noPersons.ToString();
            CalculateTotal();
        }

        private void CalculateTotal()
        {
            var totalTip = (bill * tip) / 100;

            var tipByPerson = totalTip != 0 ? totalTip / noPersons : 0;
            labelTipByPerson.Text = $"{tipByPerson:C}";

            var subtotal = bill != 0 ? bill / noPersons : 0;
            labelSubtotal.Text = $"{subtotal:C}";

            var totalBill = bill + totalTip;
            var totalByPerson = totalBill != 0 ? totalBill / noPersons : 0;
            labelTotal.Text = $"{totalByPerson:C}";
        }

        private void SetTip(int newValue)
        {
            tip = newValue;
            labelTip.Text = $"Tip: {tip}%";
            CalculateTotal();
        }
    }

}
