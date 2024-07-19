import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NavController } from '@ionic/angular';
import { ReceiptService } from '../services/receipt.service';
import { Receipt } from '../models/recepit.model';
import { format, parseISO } from 'date-fns';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.page.html',
  styleUrls: ['./edit.page.scss'],
})
export class EditPage implements OnInit {

  ReceiptDetail: Receipt= {
    receiptID: '',
    storeName:'',
    receiptDate: '',
    receiptFilePath: '',
    receiptCategory: '',
    receiptNote: '',
    receiptAmount:'',
  };

  constructor(private route: ActivatedRoute,private navCtrl: NavController, private receiptService: ReceiptService, private router:Router) { }

  ngOnInit() {

    this.route.paramMap.subscribe({
      next: (params) => {
        const receiptID = params.get('receiptID');
        if (receiptID){
          this.receiptService.ShowReceipt(receiptID).subscribe({
            next: (response) => {
              this.ReceiptDetail = response;
             

            }
          })
        }
      }
    })
    

  }

  navigateBack(){
    this.navCtrl.back();
  }


  formatDate(dateString: string): string {
    if (!dateString) return ''; // Handle cases where the date is not set
    // Parse the incoming date string and format it
    const parsedDate = parseISO(dateString);
    return format(parsedDate, 'MMM d, yyyy HH:mm');
  }

  updateReceipt(){
    this.receiptService.UpdateReceipt(this.ReceiptDetail.receiptID, this.ReceiptDetail)
    .subscribe({
      next: (response) => {
        this.router.navigate(['DigitalReceiptKeeper/ViewReceipt']).then(() => {
          window.location.reload();
        });
      }
    })
  }

}
