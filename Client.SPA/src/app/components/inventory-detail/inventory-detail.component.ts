import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { InventoryService } from 'src/app/services/inventory.service';

@Component({
  selector: 'app-inventory-detail',
  templateUrl: './inventory-detail.component.html',
  styleUrls: ['./inventory-detail.component.css']
})
export class InventoryDetailComponent implements OnInit {
  currentTutorial = null;
  message = '';

  constructor(private inventoryService: InventoryService,
    private route: ActivatedRoute,
    private router: Router) { }

  ngOnInit(): void {
    this.message = '';
    this.getInventory(this.route.snapshot.paramMap.get('id'));
  }

  getInventory(id): void {
    this.inventoryService.get(id)
      .subscribe(
        data => {
          this.currentTutorial = data;
          console.log(data);
        },
        error => {
          console.log(error);
        });
  }

  updatePublished(status): void {
    const data = {
      name: this.currentTutorial.name,
      price: this.currentTutorial.price,
      description: this.currentTutorial.description,
      // published: status
    };

    this.inventoryService.update(this.currentTutorial.id, data)
      .subscribe(
        response => {
          this.currentTutorial.published = status;
          console.log(response);
        },
        error => {
          console.log(error);
        });
  }

  updateInventory(): void {
    this.inventoryService.update(this.currentTutorial.id, this.currentTutorial)
      .subscribe(
        response => {
          console.log(response);
          this.message = 'The inventory was updated successfully!';
        },
        error => {
          console.log(error);
        });
  }

  deleteInventory(): void {
    this.inventoryService.delete(this.currentTutorial.id)
      .subscribe(
        response => {
          console.log(response);
          this.router.navigate(['/inventory']);
        },
        error => {
          console.log(error);
        });
  }
}
