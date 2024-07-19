import { Component, OnInit } from '@angular/core';
import { Receipt } from '../models/recepit.model';
import { ReceiptService } from '../services/receipt.service';
import { Router } from '@angular/router';
import { format, parseISO } from 'date-fns';

@Component({
  selector: 'app-tab2',
  templateUrl: 'tab2.page.html',
  styleUrls: ['tab2.page.scss']
})
export class Tab2Page implements OnInit {


  addReceiptRequest: Receipt= {
    receiptID: '',
    storeName:'',
    receiptDate: format(new Date(), 'yyyy-MM-dd') + 'T00:00:00.000Z',
    receiptFilePath: '',
    receiptCategory: '',
    receiptNote: '',
    receiptAmount:'',
  };

  constructor(private receiptService: ReceiptService, private router: Router) {
    }

  ngOnInit(): void {

;
  }

  formatDate(dateString: string): string {
    if (!dateString) return ''; // Handle cases where the date is not set
    // Parse the incoming date string and format it
    const parsedDate = parseISO(dateString);
    return format(parsedDate, 'MMM d, yyyy HH:mm');
  }

  addReceipt(){
    this.receiptService.AddReceipt(this.addReceiptRequest).subscribe({
      next: (receipt) => {
        this.router.navigate(['DigitalReceiptKeeper/ViewReceipt']).then(() => {
          window.location.reload();
        });

      }
    })
  }

}
