namespace APIVoiture.Data.DTOs
{
    public class ChangePasswordRequest
    {
        public string NewPassword { get; set; }
        public string ConfirmNewPassword { get; set; } 
    }
}
