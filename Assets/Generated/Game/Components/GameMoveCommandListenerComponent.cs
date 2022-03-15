//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly MoveCommandListenerComponent moveCommandListenerComponent = new MoveCommandListenerComponent();

    public bool isMoveCommandListener {
        get { return HasComponent(GameComponentsLookup.MoveCommandListener); }
        set {
            if (value != isMoveCommandListener) {
                var index = GameComponentsLookup.MoveCommandListener;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : moveCommandListenerComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherMoveCommandListener;

    public static Entitas.IMatcher<GameEntity> MoveCommandListener {
        get {
            if (_matcherMoveCommandListener == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.MoveCommandListener);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherMoveCommandListener = matcher;
            }

            return _matcherMoveCommandListener;
        }
    }
}
