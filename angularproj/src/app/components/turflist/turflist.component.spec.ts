import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TurflistComponent } from './turflist.component';

describe('TurflistComponent', () => {
  let component: TurflistComponent;
  let fixture: ComponentFixture<TurflistComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [TurflistComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(TurflistComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
