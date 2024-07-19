import { Component, OnInit } from '@angular/core';
import { QRcode } from '../models/qrcode.model';
import { QrcodeService } from '../services/qrcode.service';
import { SafeUrl } from '@angular/platform-browser';
import { ActivatedRoute, Route, Router } from '@angular/router';

@Component({
  selector: 'app-tab1',
  templateUrl: 'tab1.page.html',
  styleUrls: ['tab1.page.scss']
})

export class Tab1Page implements OnInit {
  public myQrCodecontent: string = "";
  public myQrCodelink: SafeUrl = ""
  public qrCodeDownloadLink: SafeUrl = "";

  latestqrcodes: QRcode = {
    qrCodeID: '',
    qrCodeName:'',
    qrCodeContent: '',
    qrCodeCategory: '',
    qrCodeImagePath: '',
    qrCodeCreatedTime: new Date(),
  };

  qrcodeDetails: QRcode = {
    qrCodeID: '',
    qrCodeName:'',
    qrCodeContent: '',
    qrCodeCategory: '',
    qrCodeImagePath: '',
    qrCodeCreatedTime: new Date(),
  };

  addqrcodeRequest: QRcode= {
    qrCodeID: '',
    qrCodeName:'',
    qrCodeContent: '',
    qrCodeCategory: '',
    qrCodeImagePath: '',
    qrCodeCreatedTime: new Date(),
  };

  constructor(private qrcodeService: QrcodeService, private route:ActivatedRoute, private router: Router) 
  {}
  // get new url of qrcode 
  getQRcodeURL(url:SafeUrl){
    this.myQrCodelink = url;
  }

  // get the latest QRcode
  ngOnInit(): void {
    this.qrcodeService.GetLatestQrcode().subscribe({
      next: (response) => {
        this.latestqrcodes = response;
        this.myQrCodecontent = this.latestqrcodes.qrCodeContent;
      },
      error: (err) => {
        console.error('Error fetching the latest QR code', err)
      }
    })
    
  }


  // Add new QRcode
  addQRcode(){
    this.qrcodeService.AddQrcode(this.addqrcodeRequest).subscribe({
      next: (qrcode) => {
        this.qrcodeService.GetLatestQrcode().subscribe({
          next: (response) => {
            this.latestqrcodes = response;
            this.myQrCodecontent = this.latestqrcodes.qrCodeContent;
          },
          error:(err)=> {
            console.error('Error fetching the latest QR code', err)
          }
        });

        this.router.navigate(['DigitalReceiptKeeper/QRcode']);
      },
      error: (err) => {
        console.error('Error adding the QR code', err);
      }
    })
  }


}
