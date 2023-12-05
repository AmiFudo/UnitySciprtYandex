mergeInto(LibraryManager.library, {

  getName: function() {
    myGameInstance.SendMessage('GetName','SetName', player.getName());
  },

  Save: function(date) {
    var dateString = UTF8ToString(date);
    var myobj = JSON.parse(dateString);
    player.setData(myobj);
  },

  Load: function(){
    player.getData().then(_date => {
      const myJSON = JSON.stringify(_date);
      myGameInstance.SendMessage('Menu','LoadCoin', myJSON);
    });
  },

  LoadPlayer: function(){
    player.getData().then(_date => {
      const myJSON = JSON.stringify(_date);
      myGameInstance.SendMessage('PlayerController','ProvSave', myJSON);
    });
  },

});