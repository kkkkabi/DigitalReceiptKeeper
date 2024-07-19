import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TabsPage } from './tabs.page';


const routes: Routes = [
  {
    path: 'DigitalReceiptKeeper',
    component: TabsPage,
    children: [
      {
        path: 'QRcode',
        loadChildren: () => import('../tab1-QRcode/tab1.module').then(m => m.Tab1PageModule)
      },
      {
        path: 'AddReceipt',
        loadChildren: () => import('../tab2-AddReceipt/tab2.module').then(m => m.Tab2PageModule)
      },
      {
        path: 'ViewReceipt',
        loadChildren: () => import('../tab3-ViewReceipt/tab3.module').then(m => m.Tab3PageModule)
      },
      
      {
        path: '',
        redirectTo: '/DigitalReceiptKeeper/QRcode',
        pathMatch: 'full'
      },

    ]
  },
  {
    path: '',
    redirectTo: '/DigitalReceiptKeeper/QRcode',
    pathMatch: 'full'
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
})
export class TabsPageRoutingModule {}
