﻿using System;
using UniRx;
using UnityEngine;
using UniRx.Async;
using UniRx.Async.Triggers;
using System.Threading;

namespace Catan.Scripts.Manager
{
    public class GameStateManeger : MonoBehaviour
    {

        // ステート管理するReactiveProperty
        public ReactiveProperty<GameState> _currentGameState
            = new ReactiveProperty<GameState>();

        void Start()
        {
            StateChangedAsync(this.GetCancellationTokenOnDestroy()).Forget();
        }

        /// <summary>
        /// ステート遷移するたびに処理を走らせる
        /// </summary>
        private async UniTaskVoid StateChangedAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                // ステート遷移を待つ
                var next = await _currentGameState;

                // 遷移先に合わせて処理をする
                switch (next)
                {
                    case GameState.Construction:
                        Debug.Log("construc");
                        break;
                    case GameState.AboutCard:
                        Debug.Log("aboutcard");
                        break;
                    case GameState.Trade:
                        Debug.Log("trade");
                        break;
                    case GameState.Negotiation:
                        Debug.Log("negotiation");
                        break;
                }
            }

        }
    }
}