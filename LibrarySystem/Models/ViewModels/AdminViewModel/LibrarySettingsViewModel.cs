using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.Models.ViewModels.AdminViewModel
{
    public class LibrarySettingsViewModel
    {
        [Required(ErrorMessage = "Pole jest wymagane")]
        [Range(1, 14, ErrorMessage = "Czas na odbiór musi wynosić od {1} do {2} dni.")]
        [Display(Name = "Czas na odbiór rezerwacji z półki (dni)")]
        public int ReservationPickupDays { get; set; } = 3;

        [Required(ErrorMessage = "Pole jest wymagane.")]
        [Range(7, 90, ErrorMessage = "Czas wypożyczenia musi wynosić od {1} do {2} dni.")]
        [Display(Name = "Standardowy okres wypożyczenia (dni)")]
        public int LoanDurationDays { get; set; } = 30;

        [Required(ErrorMessage = "Pole jest wymagane.")]
        [Range(0.10, 50.00, ErrorMessage = "Stawka kary musi wynosić od {1} zł do {2} zł za dzień.")]
        [Display(Name = "Stawka kary za 1 dzień zwłoki (zł)")]
        public decimal DailyPenaltyRate { get; set; } = 1.00m;

        [Required(ErrorMessage = "Pole 'Maksymalny limit wypożyczeń' jest wymagane.")]
        [Range(1, 20, ErrorMessage = "Limit wypożyczeń musi wynosić od {1} do {2} pozycji.")]
        [Display(Name = "Maksymalna liczba wypożyczonych książek na czytelnika")]
        public int MaxSimultaneousLoans { get; set; } = 5;


    }
}
