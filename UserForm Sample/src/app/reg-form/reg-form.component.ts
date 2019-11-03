import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { FormServiceService } from '../form-service.service';

@Component({
  selector: 'app-reg-form',
  templateUrl: './reg-form.component.html',
  styleUrls: ['./reg-form.component.css']
})
export class RegFormComponent implements OnInit {

  formGroup: FormGroup;
  test: FormGroup;
  editbtn = '';

  userArray = [];

  constructor(
    private fb: FormBuilder,
    private data: FormServiceService
  ) {
    this.formGroup = this.fb.group({
      firstName: [],
      lastName: [],
      gender: [],
      age: [],
      phoneNumber: [],
      email: []
    })

    this.test = this.fb.group({
      firstName: [],
      lastName: [],
      gender: [],
      age: [],
      phoneNumber: [],
      email: []
    })

  }

  onSubmit() {
     console.log(this.formGroup.value);
     this.data.saveData(this.formGroup.value);
  }

  useredit(userID) {
    this.editbtn = userID + 'edited';
    console.log(userID)
  }

  userUpdate(userID) {
    console.log(this.test.value);
    console.log(userID)
    this.editbtn = '';
  }


  userDelete(userID) {
    console.log(userID)
  }

  ngOnInit() {
    //console.log(this.formGroup);
    this.data.providerData().subscribe(data => {
      console.log(data);
      this.userArray = data;
    })
  }

}
