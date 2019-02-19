import { SpeakerErrors } from './errors';
import { SpeakerFilters } from './actions';
 
 const initialState = {
   speakerFilter: SpeakerActions.SHOW_ALL,
   speakers: [],
   errors: []
 };
 
 export function stubSpeakerReducer(state, action) {
   state = state || initialState;
   
   state.speakerFilter = action.filter || SpeakerFilters.SHOW_ALL;
   state.errors.push(SpeakerErrors.UNABLE_TO_RETRIEVE_SPEAKERS);
   
   return state;
 }
