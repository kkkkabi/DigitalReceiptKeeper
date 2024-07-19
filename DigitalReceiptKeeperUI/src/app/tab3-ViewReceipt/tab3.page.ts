import { Component, OnInit } from '@angular/core';
import { ReceiptService } from '../services/receipt.service';
import { Receipt } from '../models/recepit.model';
import { ActivatedRoute, Router } from '@angular/router';
import { format, parseISO } from 'date-fns';

@Component({
  selector: 'app-tab3',
  templateUrl: 'tab3.page.html',
  styleUrls: ['tab3.page.scss']
})
export class Tab3Page implements OnInit {

  receipts: Receipt[]=[];

  UpdateReceiptRequest: Receipt= {
    receiptID: '',
    storeName:'',
    receiptDate: '',
    receiptFilePath: '',
    receiptCategory: '',
    receiptNote: '',
    receiptAmount:'',
  };

  constructor(private receiptService: ReceiptService, private router:Router, private route: ActivatedRoute) {}

  ngOnInit(): void {
    this.receiptService.GetAllReceipt()
      .subscribe({
        next: (receipts) => {
          // Format ReceiptAmount as a currency string before displaying
          this.receipts = receipts.map(receipt => {
            return {
              ...receipt,
              receiptAmount: this.formatCurrency(receipt.receiptAmount),
              receiptDate: this.formatDate(receipt.receiptDate),
            };
          });
        },
        error: (response) => {
          console.log(response);
        }
      });
  }

  // Function to format ReceiptAmount as a currency string
  formatCurrency(amount: string): string {
    // Assuming amount is a valid number, parse it and format as currency
    const numericAmount = parseFloat(amount);
    if (!isNaN(numericAmount)) {
      return '$' + numericAmount.toFixed(2);
    }
    // If the amount is not a valid number, return it as is
    return amount;
  }

  formatDate(dateString: string): string {
    if (!dateString) return ''; // Handle cases where the date is not set
    // Parse the incoming date string and format it
    const parsedDate = parseISO(dateString);
    return format(parsedDate, 'MMM d, yyyy HH:mm');
  }

  // Navigate to the "receipt-detail" page and pass the receiptFilePath as a parameter
  navigateToReceiptDetail(receiptFilePath: string) {
    this.router.navigate(['ViewReceipt/receipt-detail', receiptFilePath]);
  }

  updateReceipt(){
    this.receiptService.UpdateReceipt(this.UpdateReceiptRequest.receiptID, this.UpdateReceiptRequest)
    .subscribe({
      next: (response) => {
        this.router.navigate(['ViewReceipt/receipt-detail'])
      }
    })
  }
  
  deleteReceipt(receiptID: string){
    this.receiptService.DeleteReceipt(receiptID)
    .subscribe({
      next:(response) => {
        this.receipts = this.receipts.filter(receipt => receipt.receiptID !== receiptID);
      },
      error:(err)=> {
        console.error('Error deleting the latest QR code', err)
      }
    })
  }

}
