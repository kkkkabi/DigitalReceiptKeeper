import { Component, OnInit } from '@angular/core';
import { Receipt } from '../models/recepit.model';
import { ActivatedRoute, Router } from '@angular/router';
import { DomSanitizer, SafeUrl } from '@angular/platform-browser';
import { NavController } from '@ionic/angular';
import { ReceiptService } from '../services/receipt.service';
import { format, parseISO } from 'date-fns';

@Component({
  selector: 'app-receipt-detail',
  templateUrl: './receipt-detail.page.html',
  styleUrls: ['./receipt-detail.page.scss'],
})
export class ReceiptDetailPage implements OnInit {

  ReceiptDetail: Receipt= {
    receiptID: '',
    storeName:'',
    receiptDate: '',
    receiptFilePath: '',
    receiptCategory: '',
    receiptNote: '',
    receiptAmount:'',
  };

  public trustedReceiptURL: SafeUrl = "";

  constructor(
    private router:Router, private sanitizer: DomSanitizer, private route: ActivatedRoute,private navCtrl: NavController, private receiptService: ReceiptService) { }

  ngOnInit() {
    this.route.paramMap.subscribe({
      next: (params) => {
        const receiptID = params.get('receiptID');
        if (receiptID){
          this.receiptService.ShowReceipt(receiptID).subscribe({
            next: (response) => {
              this.ReceiptDetail = response;
              // Sanitize the receipt URL
              this.trustedReceiptURL = this.sanitizer.bypassSecurityTrustResourceUrl(this.ReceiptDetail.receiptFilePath);

            }
          })
        }
      }
    })
    
    
  }
  formatDate(dateString: string): string {
    if (!dateString) return ''; // Handle cases where the date is not set
    // Parse the incoming date string and format it
    const parsedDate = parseISO(dateString);
    return format(parsedDate, 'MMM d, yyyy HH:mm');
  }
  

  navigateBack(){
    this.navCtrl.back();


  }
}
