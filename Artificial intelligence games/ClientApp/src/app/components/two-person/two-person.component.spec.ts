import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TwoPersonComponent } from './two-person.component';

describe('TwoPersonComponent', () => {
  let component: TwoPersonComponent;
  let fixture: ComponentFixture<TwoPersonComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TwoPersonComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TwoPersonComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
