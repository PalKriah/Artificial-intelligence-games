import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { OnePersonComponent } from './one-person.component';

describe('OnePersonComponent', () => {
  let component: OnePersonComponent;
  let fixture: ComponentFixture<OnePersonComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ OnePersonComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(OnePersonComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
