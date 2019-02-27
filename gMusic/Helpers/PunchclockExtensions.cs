// Copyright (c) 2019 .NET Foundation and Contributors. All rights reserved.
// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using System;
using System.Reactive.Linq;
using System.Reactive.Threading.Tasks;
using System.Threading;
using System.Threading.Tasks;
using Punchclock;

namespace gMusic {
	public static class PunchclockExtensions {
		public static Task<T> Enqueue<T> (this OperationQueue operationQueue, Func<Task<T>> asyncOperation) => operationQueue.Enqueue (1, asyncOperation);
		public static Task Enqueue (this OperationQueue operationQueue, Func<Task> asyncOperation) =>  operationQueue.Enqueue (1, asyncOperation);
	}
}