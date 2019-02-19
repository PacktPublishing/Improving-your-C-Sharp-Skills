export class FakeDataContext {
    _identityCounter = 1;
    _dataSet = [];
  
    get DataSet() {
      return this._dataSet;
    }
  
    set DataSet(value) {
      this._dataSet = value;
    }
  
    get(predicate) {
      if (typeof(predicate) !== 'function') {
        throw new Error('Predicate must be a function');
      }
  
      const resultSet = this_dataSet.filter(predicate);
  
      return resultSet.length >= 1 ? {...resultSet[0]} : null;
    }
  
    getAll() {
      return this._dataSet.map((x) => {
        return {...x};
      });
    }
  
    save(item) {
      return item.id ? this.update(item) : this.create(item);
    }
  
    update(item) {
      if (!this._dataSet.some(x => x.id === item.id)) {
        this._dataSet.push({...item});
      } else {
        let itemIndex = this._dataSet.findIndex(x => x.id === item.id);
        this._dataSet[itemIndex] = {...item};
      }
  
      return {...item};
    }
  
    create(item) {
      let newItem = {...item};
      newItem.id = this._identityCounter++;
      this._dataSet.push({...newItem});
  
      return {...newItem};
    }
  } 
