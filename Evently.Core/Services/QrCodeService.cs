using QRCoder;

namespace Evently.Core.Services
{
    public static class QrCodeService
    {
        // Generates PNG image bytes for a given ticket ID string
        public static byte[] GenerateTicketQrPng(string ticketId)
        {
            using var generator = new QRCodeGenerator();
            using var data = generator.CreateQrCode(ticketId, QRCodeGenerator.ECCLevel.Q);
            using var qrCode = new PngByteQRCode(data);
            return qrCode.GetGraphic(20);
        }
    }
}
