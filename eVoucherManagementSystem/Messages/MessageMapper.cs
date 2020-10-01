using eVoucherManagementSystem.Messages.DataTransferObjects;
using eVoucherManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eVoucherManagementSystem.Messages
{
    public class MessageMapper
    {
        public eVoucherDto MapToeVoucherDto(eVoucher item)
        {
            var eVoucherDto = new eVoucherDto
            {
                Id = item.Id,
                Title = item.Title,
                Description = item.Description,
                ExpiryDate = item.ExpiryDate,
                ImageURL = item.ImageURL,
                Amount = item.Amount,
                Quantity = item.Quantity,
                BuyType =  (int)item.BuyType,
                MaxCanBuyeVoucher = item.MaxCanBuyeVoucher,
                GiftPerUserBuy = item.GiftPerUserBuy,
                EVoucherStatus = (int)item.EVoucherStatus,
                CreatedBy = item.CreatedBy,
                CreatedDate = item.CreatedDate,
                UpdatedBy = item.UpdatedBy,
                UpdatedDate = item.UpdatedDate

            };
            eVoucherDto.eVoucherPaymentModeDtos = new List<eVoucherPaymentModeDto>();
            eVoucherDto.eVoucherPaymentModeDtos = MapToeVoucherPaymentModeDtos(item.eVoucherPaymentMode);
            return eVoucherDto;
        }

        public eVoucher MapToeVoucher(eVoucherDto item)
        {
            var voucher = new eVoucher
            {
                Id = item.Id,
                Title = item.Title,
                Description = item.Description,
                ExpiryDate = item.ExpiryDate,
                ImageURL = item.ImageURL,
                Amount = item.Amount,
                Quantity = item.Quantity,
                BuyType = (BuyType)item.BuyType,
                MaxCanBuyeVoucher = item.MaxCanBuyeVoucher,
                GiftPerUserBuy = item.GiftPerUserBuy,
                EVoucherStatus = (eVoucherStatus)item.EVoucherStatus,
                CreatedBy = item.CreatedBy,
                CreatedDate = item.CreatedDate,
                UpdatedBy = item.UpdatedBy,
                UpdatedDate = item.UpdatedDate
            };
            voucher.eVoucherPaymentMode = new List<eVoucherPaymentMode>();
            voucher.eVoucherPaymentMode = MapToeVoucherPaymentModes(item.eVoucherPaymentModeDtos);
            return voucher;
        }

        public eVoucherPaymentModeDto MapToeVoucherPaymentModeDto(eVoucherPaymentMode item)
        {
            eVoucherPaymentModeDto _eVoucherPaymentModeDto = null;

            _eVoucherPaymentModeDto = new eVoucherPaymentModeDto
            {
                    Id = item.Id,
                    PaymentModeId = item.PaymentModeId,
                    PaymentType = item.PaymentType,
                    eVoucherId = item.eVoucherId,
                    Discount = item.Discount,
                    CreatedBy = item.CreatedBy,
                    CreatedDate = item.CreatedDate,
                    UpdatedBy = item.UpdatedBy,
                    UpdatedDate = item.UpdatedDate
            };
          
            return _eVoucherPaymentModeDto;
        }

        public eVoucherPaymentMode MapToeVoucherPaymentMode(eVoucherPaymentModeDto item)
        {
            return new eVoucherPaymentMode
            {
                Id = item.Id,
                PaymentModeId = item.PaymentModeId,
                PaymentType = item.PaymentType,
                eVoucherId = item.eVoucherId,
                Discount = item.Discount,
                CreatedBy = item.CreatedBy,
                CreatedDate = item.CreatedDate,
                UpdatedBy = item.UpdatedBy,
                UpdatedDate = item.UpdatedDate
            };
        }

        public List<eVoucherDto> MapToeVouchersDtos(IEnumerable<eVoucher> items)
        {
            var voucherDtos = new List<eVoucherDto>();
            foreach (var item in items)
            {
                var voucherDto = MapToeVoucherDto(item);
                voucherDtos.Add(voucherDto);
            }
            return voucherDtos;
        }

        public List<eVoucherPaymentModeDto> MapToeVoucherPaymentModeDtos(IEnumerable<eVoucherPaymentMode> items)
        {
            var voucherDtos = new List<eVoucherPaymentModeDto>();
            foreach (var item in items)
            {
                var voucherDto = MapToeVoucherPaymentModeDto(item);
                voucherDtos.Add(voucherDto);
            }
            return voucherDtos;
        }

        public List<eVoucherPaymentMode> MapToeVoucherPaymentModes(IEnumerable<eVoucherPaymentModeDto> items)
        {
            var vouchers = new List<eVoucherPaymentMode>();
            foreach (var item in items)
            {
                var voucher = MapToeVoucherPaymentMode(item);
                vouchers.Add(voucher);
            }
            return vouchers;
        }

        public QRCodeDto MapToeQRCodeDto(QRCode item)
        {
            var qrCodeDto = new QRCodeDto
            {
                Id = item.Id,
                eVoucherId = item.eVoucherId,
                QRCodeImg = item.QRCodeImg,
                QRCodeImgURL = "data:image/jpg;base64," + Convert.ToBase64String((byte[])item.QRCodeImg),
                PromoCode = item.PromoCode,
                CreatedBy = item.CreatedBy,
                CreatedDate = item.CreatedDate
            };
            
            return qrCodeDto;
        }

        public QRCode MapToQRCode(QRCodeDto item)
        {
            var qrCode = new QRCode
            {
                Id = item.Id,
                eVoucherId = item.eVoucherId,
                QRCodeImg = item.QRCodeImg,                
                PromoCode = item.PromoCode,
                CreatedBy = item.CreatedBy,
                CreatedDate = item.CreatedDate
               
            };
           
            return qrCode;
        }

        public PurchaseEVoucherDto MapToePurchaseEVoucherDto(PurchaseEVoucher item)
        {
            var purchaseEVoucherDto = new PurchaseEVoucherDto
            {
                Id = item.Id,
                eVoucherId = item.eVoucherId,
                CustomerId = item.CustomerId,
                Qty = item.Qty,
                IsUsed = item.IsUsed,
                QRCodeId = item.QRCodeId,
                Name = item.Name,
                PhoneNo = item.PhoneNo,
                CreatedDate = item.CreatedDate
            };

            return purchaseEVoucherDto;
        }

        public PurchaseEVoucher MapToePurchaseEVoucher(PurchaseEVoucherDto item)
        {
            var purchaseEVoucher = new PurchaseEVoucher
            {
                Id = item.Id,
                eVoucherId = item.eVoucherId,
                CustomerId = item.CustomerId,
                Qty = item.Qty,
                IsUsed = item.IsUsed,
                QRCodeId = item.QRCodeId,
                Name = item.Name,
                PhoneNo = item.PhoneNo,
                CreatedDate = item.CreatedDate
            };

            return purchaseEVoucher;
        }
    }
}
