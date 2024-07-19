import { NgModule } from '@angular/core';
import { PreloadAllModules, RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: '',
    loadChildren: () => import('./tabs/tabs.module').then(m => m.TabsPageModule)
  },
  {
    path: 'receipt-detail/:receiptID',
    loadChildren: () => import('./receipt-detail/receipt-detail.module').then( m => m.ReceiptDetailPageModule)
  },
  {
    path: 'edit/:receiptID',
    loadChildren: () => import('./edit/edit.module').then( m => m.EditPageModule)
  },
];
@NgModule({
  imports: [
    RouterModule.forRoot(routes, { preloadingStrategy: PreloadAllModules })
  ],
  exports: [RouterModule]
})
export class AppRoutingModule {}
