import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TurfformComponent } from './turfform.component';

describe('TurfformComponent', () => {
  let component: TurfformComponent;
  let fixture: ComponentFixture<TurfformComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [TurfformComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(TurfformComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
