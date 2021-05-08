import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { InventoryService } from 'src/app/services/inventory.service';

@Component({
  selector: 'app-add-inventory',
  templateUrl: './add-inventory.component.html',
  styleUrls: ['./add-inventory.component.css']
})
export class AddInventoryComponent implements OnInit {

  public createForm = this.fb.group({
    name: ['', [Validators.required, Validators.minLength(2), Validators.maxLength(50)]],
    price: ['', [Validators.required, Validators.minLength(2), Validators.maxLength(50)]],
    description: ['', [Validators.required]]
  });

  loading: boolean;
  submitted = false;

  constructor(private inventoryService: InventoryService,
    private fb: FormBuilder
  ) { }

  ngOnInit(): void {
  }

  saveTutorial(): void {
    if (this.createForm.valid) {
      const model = this.createForm.value;
      model.price = this.createForm.controls.price.value.toString();
      this.inventoryService.create(model)
        .subscribe(
          response => {
            console.log(response);
            this.submitted = true;
          },
          error => {
            console.log(error);
          });
    }
  }

  newTutorial(): void {
    this.submitted = false;
  }
}
