import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewBloodtestComponent } from './view-bloodtest.component';

describe('ViewBloodtestComponent', () => {
  let component: ViewBloodtestComponent;
  let fixture: ComponentFixture<ViewBloodtestComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ViewBloodtestComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ViewBloodtestComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
