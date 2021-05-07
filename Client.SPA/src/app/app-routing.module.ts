import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AddInventoryComponent } from './components/add-inventory/add-inventory.component';
import { InventoryDetailComponent } from './components/inventory-detail/inventory-detail.component';
import { InventoryListComponent } from './components/inventory-list/inventory-list.component';

const routes: Routes = [
  { path: '', redirectTo: 'inventory', pathMatch: 'full' },
  { path: 'inventory', component: InventoryListComponent },
  { path: 'inventory/:id', component: InventoryDetailComponent },
  { path: 'add-inventory', component: AddInventoryComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
