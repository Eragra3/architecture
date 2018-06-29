import {async, ComponentFixture, TestBed} from '@angular/core/testing';

import {LearningProgramComponent} from './learning-program.component';

describe('LearningProgramComponent', () => {
  let component: LearningProgramComponent;
  let fixture: ComponentFixture<LearningProgramComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [LearningProgramComponent]
    })
      .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LearningProgramComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
