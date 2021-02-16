using HSRM.Core.Collectables;
namespace HSRM.Core.Commands
{

    public class CollectCollectableCommand : BaseCommand
    {
        public Collectable Collectable { get; protected set; }

        public bool HasCollectable => Collectable != null;
        
        public override bool CanExecute
        {
            get => base.CanExecute && HasCollectable;
            set => base.CanExecute = value;
        }

        public void SetCollectable(Collectable collectable)
        {
            Collectable = collectable;
        }

        public void CollectCollectable(Collectable collectable)
        {
            SetCollectable(collectable);
            Execute();
        }

        protected override void ExecuteCommand()
        {
            Collectable.Collect();
            ClearCollectable();
        }

        public void ClearCollectable()
        {
            Collectable = null;
        }

    }

}