using pAssistant.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace pAssistant.ViewModel
{
    class VMInteractionHandler
    {
        public static PassinstantVM PassinstantVM { get; set; }
        public static EntryDetailsVM EntryDetailsVM { get; set; }

        public static Entry SelectedEntry { get; set; }

        public VMInteractionHandler()
        {
            SelectedEntry = new Entry();
        }

        public static void UpdateEntryList()
        {
            PassinstantVM.UpdateEntries();
        }

        public static void SetEntryToEdit(Entry entry)
        {
            SelectedEntry = entry;
        }
    }
}
