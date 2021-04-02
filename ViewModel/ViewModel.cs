using System.ComponentModel;
using System.Windows.Input;
// using Repositories;
// using Models;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Diagnostics;

namespace ViewModel
{

    public class SamuraiBattleViewModel : INotifyPropertyChanged
    {

        #region  Fields
        protected IRepository Repository;
        SamuraiBattleViewModel viewModel;
        #region Fields of Samurai
        public int samuraiId;
        public string samuraiName;
        public int samuraiAge;
        public string samuraiTown;

        public Samurai samurai;                // store one Samurai
        private IEnumerable<Samurai> _warriors;
        public IEnumerable<Samurai> Warriors   // store the List of Samurais 
        {
            get { return _warriors; }
            set
            {
                if (_warriors == value)
                    return;
                _warriors = value;

                RaisePropertyChanged("Warriors");
            }
        }
        #endregion
        #region fields of Battle
        public int battleId;
        public string battleName;
        public DateTime battleDate;
        public string battleCity;
        public string battleCountry;

        public Battle battle;
        private IEnumerable<Battle> _contests;  // store one Battle
        public IEnumerable<Battle> Contests     // store the List of Battles

        {
            get { return _contests; }
            set
            {
                if (_contests == value)
                    return;
                _contests = value;
                // 
                RaisePropertyChanged("Battle");
            }
        }
        #endregion
        #endregion

        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        public SamuraiBattleViewModel(IRepository repository)
        {
            Repository = repository;
        }



        #endregion

        #region Commands
        #region Commands group1

        #region RefreshCommand1 


        private RefreshCommand1 _refreshSamuraiCommand = new RefreshCommand1();
        public RefreshCommand1 RefreshSamuraiCommand
        {
            get
            {
                if (_refreshSamuraiCommand.ViewModel == null)
                    _refreshSamuraiCommand.ViewModel = this;
                return _refreshSamuraiCommand;
            }
        }

        /// <summary>
        /// RefreshCommand Button 1 : Fetch data of Samurai with Asyn/await
        /// </summary>
        public class RefreshCommand1 : ICommand
        {
            public SamuraiBattleViewModel ViewModel { get; set; }
            public event EventHandler CanExecuteChanged;
            public bool CanExecute(object parameter)
            {
                return true;
            }
            #endregion RefreshCommand1 Standard Stuff

            public async void Execute(object parameter)
            {
                Task t1 = new Task
               (
                  () =>
                  {
                      ViewModel.Warriors = ViewModel.Repository.GetWarriors();
                  }
               );
                // start the task
                t1.Start();

                await t1;

            }

        }
        #endregion

        #region ClearCommand1 

        private ClearCommand1 _clearSamuraiCommand = new ClearCommand1();
        public ClearCommand1 ClearSamuraiCommand
        {
            get
            {
                if (_clearSamuraiCommand.ViewModel == null)
                    _clearSamuraiCommand.ViewModel = this;
                return _clearSamuraiCommand;
            }
        }

        public class ClearCommand1 : ICommand
        {
            public SamuraiBattleViewModel ViewModel { get; set; }
            public event EventHandler CanExecuteChanged;
            public bool CanExecute(object parameter)
            {
                return true;
            }

            public void Execute(object parameter)
            {
                ViewModel.Warriors = new List<Samurai>();
            }
        }
        ////
        #endregion
        #region UpdateCommand1  

        private UpdateCommand1 _updateSamuraiCommand = new UpdateCommand1();
        public UpdateCommand1 UpdateSamuraiCommand
        {
            get
            {
                if (_updateSamuraiCommand.ViewModel == null)
                    _updateSamuraiCommand.ViewModel = this;
                return _updateSamuraiCommand;
            }
        }

        public class UpdateCommand1 : ICommand
        {
            public SamuraiBattleViewModel ViewModel { get; set; }
            public event EventHandler CanExecuteChanged;
            public bool CanExecute(object parameter)
            {
                // Can not execute Update if null
                if (ViewModel == null)
                    return false;
                // Can execute if Samurai Name is not null
                return (!String.IsNullOrWhiteSpace(ViewModel.samuraiName));
            }

            public void Execute(object parameter)
            {
                ViewModel.Repository.UpdateSamurai(ViewModel.samuraiName,
                                                   ViewModel.samuraiAge,
                                                   ViewModel.samuraiTown);

            }
        }
        #endregion
        #endregion

        #region Commands group2


        /// <summary>
        /// Commands of Battle
        /// </summary>
        #region RefreshCommand2  



        private RefreshCommand2 _refreshBattleCommand = new RefreshCommand2();
        public RefreshCommand2 RefreshBattleCommand
        {
            get
            {
                if (_refreshBattleCommand.ViewModel == null)
                    _refreshBattleCommand.ViewModel = this;
                return _refreshBattleCommand;
            }
        }

        /// <summary>
        /// RefreshCommand Button 2 : Fetch data of Battle with Asyn/await
        /// </summary>
        public class RefreshCommand2 : ICommand
        {
            public SamuraiBattleViewModel ViewModel { get; set; }
            public event EventHandler CanExecuteChanged;
            public bool CanExecute(object parameter)
            {
                return true;
            }
            #endregion RefreshCommand2 Standard Stuff

            public async void Execute(object parameter)
            {
                Task t2 = new Task
               (
                  () =>
                  {
                      ViewModel.Contests = ViewModel.Repository.GetContests();
                  }
               );
                // start the task
                t2.Start();
                await t2;
            }
        }
        #endregion
        #region ClearCommand2 

        private ClearCommand2 _clearBattleCommand = new ClearCommand2();
        public ClearCommand2 ClearBattleCommand
        {
            get
            {
                if (_clearBattleCommand.ViewModel == null)
                    _clearBattleCommand.ViewModel = this;
                return _clearBattleCommand;
            }
        }

        public class ClearCommand2 : ICommand
        {
            public SamuraiBattleViewModel ViewModel { get; set; }
            public event EventHandler CanExecuteChanged;
            public bool CanExecute(object parameter)
            {
                return true;
            }



            public void Execute(object parameter)
            {
                ViewModel.Contests = new List<Battle>();
            }
        }
        #endregion
        #region UpdateCommand2  

        private UpdateCommand2 _updateBattleCommand = new UpdateCommand2();
        public UpdateCommand2 UpdateBattleCommand
        {
            get
            {
                if (_updateBattleCommand.ViewModel == null)
                    _updateBattleCommand.ViewModel = this;
                return _updateBattleCommand;
            }
        }

        public class UpdateCommand2 : ICommand
        {
            public SamuraiBattleViewModel ViewModel { get; set; }
            public event EventHandler CanExecuteChanged;
            public bool CanExecute(object parameter)
            {
                // Can not execute Update if null
                if (ViewModel == null)
                    return false;
                // Can execute if Samurai Name is not null
                return (!String.IsNullOrWhiteSpace(ViewModel.battleName));
            }

            public void Execute(object parameter)
            {
                ViewModel.Repository.UpdateBattle(ViewModel.battleName,
                                                  ViewModel.battleDate,
                                                  ViewModel.battleCity,
                                                  ViewModel.battleCountry);

            }
        }
        #endregion
        #region   AddSamuraiCommand
        private AddCommand _addSamuraiCommand = new AddCommand();
        public AddCommand AddSamuraiCommand
        {
            get
            {
                if (_addSamuraiCommand.ViewModel == null)
                    _addSamuraiCommand.ViewModel = this;
                return _addSamuraiCommand;
            }
        }

        public class AddCommand : ICommand
        {
            public SamuraiBattleViewModel ViewModel { get; set; }
            public event EventHandler CanExecuteChanged;
            public bool CanExecute(object parameter)
            {
                // Can not execute add if null
                if (ViewModel == null)
                    return false;
                // Can execute if Samurai Name is not null
                return (!String.IsNullOrWhiteSpace(ViewModel.battleName));
            }

            public void Execute(object parameter)
            {
                ViewModel.Repository.AddSamuraiBattle(ViewModel.samuraiId,
                                                  ViewModel.battleId);

            }
        }
        #endregion

        #region functions
        #region function GetAllSamurai()
        void GetAllSamurai()
        {
            _warriors = Repository.GetWarriors();
        }
        #endregion
        #region function GetSamuraiById(int id)
        void GetSamuraiById(int id)
        {
            samurai = Repository.GetSamurai(id);
        }
        #endregion
        #region function UpdateBattle(Name,Date,City,Country)
        void UpdateSamurai()
        {
            Repository.UpdateBattle(battleName,
                                    battleDate,
                                    battleCity,
                                    battleCountry);
        }
        #endregion
        #region function GetAllBattle()
        void GetAllBattle()
        {
            Contests = Repository.GetContests();
        }
        #endregion
        #region function GetBattleById(int id)
        void GetBattleById(int id)
        {
            battle = Repository.GetBattle(id);
        }
        #endregion
        #region function UpdateBattle(Name,Date,City,Country)
        void UpdateBattle()
        {
            Repository.UpdateBattle(battleName,
                                    battleDate,
                                    battleCity,
                                    battleCountry);
        }
        #endregion
        #region function AddSamuraiToBattle(SamuraiId,BattleId)
        void AddSamuraiToBattle(int samuraiId, int battleId)
        {
            Repository.AddSamuraiBattle(samuraiId, battleId);
        }
        #endregion



        #endregion
        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

    }
}
