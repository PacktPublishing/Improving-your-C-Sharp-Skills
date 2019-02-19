import React, { Component } from 'react';
import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';
import * as speakerActions from '../actions/speakerActions';
import SpeakerDetail from './SpeakerDetail';

export class SpeakerDetailPage extends Component {
    constructor(state, context) {
      super(state, context);
  
      this.state = {
        speaker: Object.assign({}, this.props.speaker)
      };
  
      this.props.actions.getSpeaker(this.props.match.params.id)
    }
  
    componentWillReceiveProps(nextProps) {
      if(this.props.speaker.id !== nextProps.speaker.id) {
        this.setState({ speaker: Object.assign({}, nextProps.speaker) });
      }
    }
  
    render() {
      return (
        <SpeakerDetail speaker={this.state.speaker} />
      );
    }
  }
  
  function mapStateToProps(state, ownProps) {
    let speaker = { id: '', firstName: '', lastName: '' }
  
    return {
      speaker: state.speaker || speaker
    };
  }
  
  function mapDispatchToProps(dispatch) {
    return {
      actions: bindActionCreators(speakerActions, dispatch)
    }
  }
  
  export default  connect(
    mapStateToProps,
    mapDispatchToProps
  )(SpeakerDetailPage);
