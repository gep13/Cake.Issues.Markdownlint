﻿namespace Cake.Issues.Markdownlint
{
    using Cake.Issues.Markdownlint.Markdownlint;
    using Core;
    using Core.Annotations;
    using Core.IO;

#pragma warning disable SA1601 // Partial elements must be documented
    public static partial class MarkdownlintIssuesAliases
#pragma warning restore SA1601 // Partial elements must be documented
    {
        /// <summary>
        /// Gets the name of the Markdownlint issue provider.
        /// This name can be used to identify issues based on the <see cref="IIssue.ProviderType"/> property.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>Name of the Markdownlint issue provider.</returns>
        [CakePropertyAlias]
        [CakeAliasCategory(IssuesAliasConstants.IssueProviderCakeAliasCategory)]
        [CakeNamespaceImport("Cake.Issues.Markdownlint.Markdownlint")]
        public static string MarkdownlintIssuesProviderTypeName(
            this ICakeContext context)
        {
            context.NotNull(nameof(context));

            return typeof(MarkdownlintIssuesProvider).FullName;
        }

        /// <summary>
        /// Gets an instance of a provider for issues reported by Markdownlint using a log file from disk.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="logFilePath">Path to the the Markdownlint log file.</param>
        /// <returns>Instance of a provider for issues reported by Markdownlint.</returns>
        /// <example>
        /// <para>Read issues reported by Markdownlint:</para>
        /// <code>
        /// <![CDATA[
        ///     var issues =
        ///         ReadIssues(
        ///             MarkdownlintIssuesFromFilePath(@"c:\build\Markdownlint.log"),
        ///             @"c:\repo");
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory(IssuesAliasConstants.IssueProviderCakeAliasCategory)]
        [CakeNamespaceImport("Cake.Issues.Markdownlint.Markdownlint")]
        public static IIssueProvider MarkdownlintIssuesFromFilePath(
            this ICakeContext context,
            FilePath logFilePath)
        {
            context.NotNull(nameof(context));
            logFilePath.NotNull(nameof(logFilePath));

            return context.MarkdownlintIssues(MarkdownlintIssuesSettings.FromFilePath(logFilePath));
        }

        /// <summary>
        /// Gets an instance of a provider for issues reported by Markdownlint using log file content.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="logFileContent">Content of the the Markdownlint log file.</param>
        /// <returns>Instance of a provider for issues reported by Markdownlint.</returns>
        /// <example>
        /// <para>Read issues reported by Markdownlint:</para>
        /// <code>
        /// <![CDATA[
        ///     var issues =
        ///         ReadIssues(
        ///             MarkdownlintIssuesFromContent(logFileContent),
        ///             @"c:\repo");
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory(IssuesAliasConstants.IssueProviderCakeAliasCategory)]
        [CakeNamespaceImport("Cake.Issues.Markdownlint.Markdownlint")]
        public static IIssueProvider MarkdownlintIssuesFromContent(
            this ICakeContext context,
            string logFileContent)
        {
            context.NotNull(nameof(context));
            logFileContent.NotNullOrWhiteSpace(nameof(logFileContent));

            return context.MarkdownlintIssues(MarkdownlintIssuesSettings.FromContent(logFileContent));
        }

        /// <summary>
        /// Gets an instance of a provider for issues reported by Markdownlint using specified settings.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">Settings for reading the Markdownlint log.</param>
        /// <returns>Instance of a provider for issues reported by Markdownlint.</returns>
        /// <example>
        /// <para>Read issues reported by Markdownlint:</para>
        /// <code>
        /// <![CDATA[
        ///     var settings =
        ///         new MarkdownlintIssuesSettings("C:\build\Markdownlint.log");
        ///
        ///     var issues =
        ///         ReadIssues(
        ///             MarkdownlintIssuesFromFilePath(settings),
        ///             @"c:\repo");
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory(IssuesAliasConstants.IssueProviderCakeAliasCategory)]
        [CakeNamespaceImport("Cake.Issues.Markdownlint.Markdownlint")]
        public static IIssueProvider MarkdownlintIssues(
            this ICakeContext context,
            MarkdownlintIssuesSettings settings)
        {
            context.NotNull(nameof(context));
            settings.NotNull(nameof(settings));

            return new MarkdownlintIssuesProvider(context.Log, settings);
        }
    }
}