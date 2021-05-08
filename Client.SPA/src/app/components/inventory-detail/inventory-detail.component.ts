import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { InventoryService } from 'src/app/services/inventory.service';

@Component({
  selector: 'app-inventory-detail',
  templateUrl: './inventory-detail.component.html',
  styleUrls: ['./inventory-detail.component.css']
})
export class InventoryDetailComponent implements OnInit {
  public currentTutorial = this.fb.group({
    name: ['', [Validators.required, Validators.minLength(2), Validators.maxLength(50)]],
    price: ['', [Validators.required, Validators.minLength(2), Validators.maxLength(50)]],
    description: ['', [Validators.required]]
  });

  model = null;
  message = '';

  constructor(private inventoryService: InventoryService,
    private route: ActivatedRoute,
    private fb: FormBuilder,
    private router: Router) { }

  ngOnInit(): void {
    this.message = '';
    this.getInventory(this.route.snapshot.paramMap.get('id'));
  }

  getInventory(id): void {
    this.inventoryService.get(id)
      .subscribe(
        data => {
          this.model = data;
          this.currentTutorial.patchValue(data);
          console.log(data);
        },
        error => {
          console.log(error);
        });
  }

  // updatePublished(status): void {
  //   const data = {
  //     name: this.currentTutorial.name,
  //     price: this.currentTutorial.price,
  //     description: this.currentTutorial.description,
  //     // published: status
  //   };

  //   this.inventoryService.update(this.currentTutorial.id, data)
  //     .subscribe(
  //       response => {
  //         this.currentTutorial.published = status;
  //         console.log(response);
  //       },
  //       error => {
  //         console.log(error);
  //       });
  // }

  updateInventory(): void {
    if (this.currentTutorial.valid) {
      const data = this.currentTutorial.value;
      data.id = this.model.id;
      data.price = this.currentTutorial.controls.price.value.toString();
      this.inventoryService.update(this.model.id, data)
        .subscribe(
          response => {
            console.log(response);
            this.message = 'The inventory was updated successfully!';
          },
          error => {
            console.log(error);
          });
    }
  }

  deleteInventory(): void {
    this.inventoryService.delete(this.model.id)
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
