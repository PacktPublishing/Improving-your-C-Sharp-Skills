import { expect } from 'chai';
import SpeakerService from './speakerService';
import MockSpeakerService from './mockSpeakerService';
import factory from './serviceFactory';
 
describe('Service Factory', () => {
  it('exits', () => {
    expect(factory).to.exist;
  });

  describe('Create Speaker Service', () => {
    it('exists', () => {
      expect(factory.createSpeakerService).to.exist;
    });
  });

  it('returns a speaker service', () => {
    // act
    let result = factory.createSpeakerService();
  
    // assert
    expect(result).to.be.an.instanceOf(SpeakerService);
  });

  it('returns the same speaker service', () => {
    // act
    let service1 = factory.createSpeakerService();
    let service2 = factory.createSpeakerService();
  
    // assert
    expect(service1).to.equal(service2);
  });
});
