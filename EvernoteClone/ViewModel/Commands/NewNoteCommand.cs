using EvernoteClone.Model;
using EvernoteClone.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.ServiceProcess;
using System.Xaml;

namespace EvernoteClone.ViewModel.Commands
{
    public class NewNoteCommand : ICommand
    {
        public NotesVM VM { get; set; }
        public event EventHandler? CanExecuteChanged;

        public NewNoteCommand(NotesVM vm)
        {
            VM = VM;
        }
        public bool CanExecute(object? parameter)
        {
            Notebook selectedNotebook = parameter as Notebook;
            if(selectedNotebook != null)
                return true;

            return false;
        }

        public void Execute(object? parameter)
        {
            Notebook selectedNotebook = parameter as Notebook;
            VM.CreateNote(selectedNotebook.Id);
            
            //TODO: get notes
        }
    }
}
