using eVoucherManagementSystem.Messages;
using eVoucherManagementSystem.Messages.DataTransferObjects;
using eVoucherManagementSystem.Messages.Request.QRCode;
using eVoucherManagementSystem.Messages.Response.QRCode;
using eVoucherManagementSystem.Repositories;
//using QRCoder;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using eVoucherManagementSystem.Models;

namespace eVoucherManagementSystem.Services.Implementation
{
    public class QRCodeService:IQRCodeService
    {
        private readonly IQRCodeRepository _qRCodeRepository;
        private MessageMapper _messageMapper;
        public QRCodeService(IQRCodeRepository qRCodeRepository)
        {
            _qRCodeRepository = qRCodeRepository;
            _messageMapper = new MessageMapper();
        }
        private string GeneratePromoteCode()
        {
            const string src = "abcdefghijklmnopqrstuvwxyz0123456789";
            int length = 12;
            var sb = new StringBuilder();
            Random RNG = new Random();
            for (var i = 0; i < length; i++)
            {
                var c = src[RNG.Next(0, src.Length)];
                sb.Append(c);
            }
            return sb.ToString();
        }

        public CreateQRCodeResponse CreateQRCode(CreateQRCodeRequest createQRCodeRequest)
        {
            int count = _qRCodeRepository.GetAlleQRCodes()
                    .Where(x => x.eVoucherId == createQRCodeRequest.eVoucharId).Count();
            if(count < 1000)
            {
                string promoCode = String.Empty;
                string imageURL = string.Empty;
                QRCode obj = new QRCode();
                obj.Id = Guid.NewGuid();
                obj.eVoucherId = createQRCodeRequest.eVoucharId;
                bool isAlreadyHave = false;
                do
                {
                    promoCode = GeneratePromoteCode();
                    isAlreadyHave = _qRCodeRepository.CheckPromoCode(promoCode);
                }
                while (isAlreadyHave);
                obj.PromoCode = promoCode;
                QRCoder.QRCodeGenerator qrGenerator = new QRCoder.QRCodeGenerator();
                QRCoder.QRCodeData qrCodeData = qrGenerator.CreateQrCode(promoCode, QRCoder.QRCodeGenerator.ECCLevel.Q);
                QRCoder.QRCode qrCode = new QRCoder.QRCode(qrCodeData);
                try
                {
                    using (Bitmap bitMap = qrCode.GetGraphic(20))
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                            byte[] byteImage = ms.ToArray();
                            imageURL = "data:image/png;base64," + Convert.ToBase64String(byteImage);
                            obj.QRCodeImg = byteImage;
                            obj.CreatedBy = "System";
                            obj.CreatedDate = DateTime.Now;
                            _qRCodeRepository.CreateQRCode(obj);
                            var qrDto = _messageMapper.MapToeQRCodeDto(obj);
                            var createResponse = new CreateQRCodeResponse
                            {
                                codeDto = qrDto,
                                StatusCode = System.Net.HttpStatusCode.OK

                            };
                            return createResponse;
                        }
                    }
                }
                catch (Exception ex)
                {
                    var createResponse = new CreateQRCodeResponse
                    {
                        StatusCode = System.Net.HttpStatusCode.BadRequest
                    };
                    return createResponse;
                }
            }
            else
            {
                string messageStr = "QRCode generation exceed limitation!";
                List<string> msgList = new List<string>();
                msgList.Add(messageStr);
                var createResponse = new CreateQRCodeResponse
                {
                    Messages = msgList
                };
                return createResponse;
            }
            
            
        } 

        
    }
}
