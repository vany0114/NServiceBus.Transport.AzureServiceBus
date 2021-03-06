﻿namespace NServiceBus.Transport.AzureServiceBus.AcceptanceTests
{
    using System.Threading.Tasks;
    using AcceptanceTesting;
    using MessageMutator;

    class TestIndependenceMutator : IMutateOutgoingTransportMessages
    {
        readonly string testRunId;

        public TestIndependenceMutator(ScenarioContext scenarioContext)
        {
            testRunId = scenarioContext.TestRunId.ToString();
        }

        public Task MutateOutgoing(MutateOutgoingTransportMessageContext context)
        {
            context.OutgoingHeaders["$AcceptanceTesting.TestRunId"] = testRunId;
            return Task.CompletedTask;
        }
    }
}