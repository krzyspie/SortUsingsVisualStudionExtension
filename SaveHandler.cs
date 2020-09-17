using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Microsoft.VisualStudio.Commanding;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Editor.Commanding;
using Microsoft.VisualStudio.Text.Editor.Commanding.Commands;
using Microsoft.VisualStudio.Utilities;

namespace FirstSimpleExtension
{
    [Export(typeof(ICommandHandler))]
    [Name(nameof(SaveHandler))]
    [ContentType(StandardContentTypeNames.Code)]
    [TextViewRole(PredefinedTextViewRoles.PrimaryDocument)]
    public class SaveHandler : ICommandHandler<SaveCommandArgs>
    {
        public string DisplayName => nameof(SaveHandler);

        private readonly IEditorCommandHandlerServiceFactory _commandService;

        private int? usingsStartIndex = null;

        [ImportingConstructor]
        public SaveHandler(IEditorCommandHandlerServiceFactory commandService)
        {
            _commandService = commandService;
        }

        public bool ExecuteCommand(SaveCommandArgs args, CommandExecutionContext executionContext)
        {
            // Do not execute action if file is not a cs file
            if (!IsCsFile(args))
            {
                return true;
            }

            if (FileNotChanged(args.SubjectBuffer.Properties))
            {
                return true;
            }

            RemoveUnnecessaryUsingsAndSort(args);

            List<string> usings = GetUsings(args.SubjectBuffer.CurrentSnapshot);

            if (usings.Count == 0)
            {
                return true;
            }

            var systemUsings = usings.Where(x => x.StartsWith("System")).ToList();
            var bleepaUsings = usings.Where(x => x.StartsWith("Bleepa")).ToList();
            var externalUsings = usings.Where(x => !x.StartsWith("System") && !x.StartsWith("Bleepa")).ToList();

            if (bleepaUsings.Count == 0)
            {
                return true;
            }

            var orderedSystemUsings = systemUsings.OrderBy(x => x);
            var orderedBleepaUsings = bleepaUsings.OrderBy(x => x);
            var orderedExternalUsings = externalUsings.OrderBy(x => x);

            var orderedUsings = new List<string>();
            orderedUsings.AddRange(orderedSystemUsings);
            orderedUsings.AddRange(orderedExternalUsings);
            orderedUsings.AddRange(orderedBleepaUsings);

            OrderUsings(args, usings.Count, orderedUsings);

            usingsStartIndex = null;

            return true;
        }

        private static bool FileNotChanged(PropertyCollection properties)
        {
            ITextDocument document;
            properties.TryGetProperty(typeof(ITextDocument), out document);

            return document != null && !document.IsDirty;
        }

        private void OrderUsings(SaveCommandArgs args, int usingsCount, List<string> orderedUsings)
        {
            for (int i = usingsStartIndex.Value; i < usingsCount + usingsStartIndex.Value; i++)
            {
                var line = args.TextView.TextBuffer.CurrentSnapshot.GetLineFromLineNumber(i);
                var lineBreak = line.GetLineBreakText();
                var newUsing = $"using {orderedUsings[i - usingsStartIndex.Value]};{lineBreak}";
                args.TextView.TextBuffer.Replace(line.ExtentIncludingLineBreak.Span, newUsing);
            }
        }

        private static bool IsCsFile(SaveCommandArgs args)
        {
            return args.SubjectBuffer.ContentType.TypeName.ToLower() == "csharp";
        }

        private List<string> GetUsings(ITextSnapshot currentSnapshot)
        {
            var usings = new List<string>();

            for (int i = 0; i < currentSnapshot.LineCount; i++)
            {
                var line = currentSnapshot.GetLineFromLineNumber(i);
                var lineText = line.GetText();

                if (lineText.StartsWith("using "))
                {
                    var removedUsingPrefix = lineText.Remove(0, 6);
                    var removedSemicolon = removedUsingPrefix.Remove(removedUsingPrefix.Length - 1, 1);
                    usings.Add(removedSemicolon);
                    if (!usingsStartIndex.HasValue)
                    {
                        usingsStartIndex = i;
                    }

                    continue;
                }

                if (lineText.StartsWith("namespace "))
                {
                    break;
                }
            }

            return usings;
        }

        private void RemoveUnnecessaryUsingsAndSort(SaveCommandArgs args)
        {
            IEditorCommandHandlerService service = _commandService.GetService(args.TextView);
            var cmd = new CodeCleanUpDefaultProfileCommandArgs(args.TextView, args.SubjectBuffer);
            service.Execute((v, b) => cmd, null);
        }

        public CommandState GetCommandState(SaveCommandArgs args)
        {
            return CommandState.Available;
        }
    }
}
