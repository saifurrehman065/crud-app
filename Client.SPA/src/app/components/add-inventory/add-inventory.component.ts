import { Component, OnInit } from '@angular/core';
import { InventoryService } from 'src/app/services/inventory.service';

@Component({
  selector: 'app-add-inventory',
  templateUrl: './add-inventory.component.html',
  styleUrls: ['./add-inventory.component.css']
})
export class AddInventoryComponent implements OnInit {

  tutorial = {
    name: '',
    price: 0,
    description: '',
    published: false
  };
  submitted = false;

  constructor(private inventoryService: InventoryService) { }

  ngOnInit(): void {
  }

  saveTutorial(): void {
    const data = {
      name: this.tutorial.name,
      price: this.tutorial.price,
      description: this.tutorial.description
    };
  
      this.inventoryService.create(data)
        .subscribe(
          response => {
            console.log(response);
            this.submitted = true;
          },
          error => {
            console.log(error);
          });
    }

    newTutorial(): void {
      this.submitted = false;
      this.tutorial = {
        name: '',
        price: 0,
        description: '',
        published: false
      };
    }

}
