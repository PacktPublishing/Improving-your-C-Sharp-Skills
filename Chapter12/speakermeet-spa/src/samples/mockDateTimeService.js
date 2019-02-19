export class MockDateTimeService {
  constructor() {
    this.currentDateTime = new Date(2000, 0, 1);
  }

  now() {
    return this.currentDateTime;
  }
}
