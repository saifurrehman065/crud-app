import { Component, OnInit } from '@angular/core';
import { InventoryService } from 'src/app/services/inventory.service';

@Component({
  selector: 'app-inventory-list',
  templateUrl: './inventory-list.component.html',
  styleUrls: ['./inventory-list.component.css']
})
export class InventoryListComponent implements OnInit {

  inventories: any;
  currentInventory = null;
  currentIndex = -1;
  title = '';

  constructor(private inventoryService: InventoryService) { }

  ngOnInit(): void {
    this.retrieveTutorials();
  }

  retrieveTutorials(): void {
    this.inventoryService.getAll()
      .subscribe(
        data => {
          this.inventories = data;
          console.log(data);
        },
        error => {
          console.log(error);
        });
  }


  refreshList(): void {
    this.retrieveTutorials();
    this.currentInventory = null;
    this.currentIndex = -1;
  }

  setActiveTutorial(tutorial, index): void {
    this.currentInventory = tutorial;
    this.currentIndex = index;
  }

  removeAllTutorials(): void {
    this.inventoryService.deleteAll()
      .subscribe(
        response => {
          console.log(response);
          this.retrieveTutorials();
        },
        error => {
          console.log(error);
        });
  }

  searchTitle(): void {
    this.inventoryService.findByTitle(this.title)
      .subscribe(
        data => {
          this.inventoryService = data;
          console.log(data);
        },
        error => {
          console.log(error);
        });
  }
}
