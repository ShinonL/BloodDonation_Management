import { Component, Inject, OnInit } from '@angular/core';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { BloodTestModel } from '../models/bloodTest.model';

@Component({
  selector: 'app-view-bloodtest',
  templateUrl: './view-bloodtest.component.html',
  styleUrls: ['./view-bloodtest.component.scss']
})
export class ViewBloodtestComponent implements OnInit {

  constructor(private dialogRef: MatDialogRef<MatDialog>,
    @Inject(MAT_DIALOG_DATA) public data: { bloodTest: BloodTestModel }) { }

  ngOnInit(): void {
  }

  onClose(): void {
    this.dialogRef.close();
  }
}
