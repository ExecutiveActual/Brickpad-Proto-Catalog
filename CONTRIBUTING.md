# Contributing to Brickpad Proto-Catalog

This repository is the Unity package. It is not a game and it is not a Unity project. Code lands here after it has worked in a prototype and is ready for another Unity 6 project to install.

The games this catalog comes from are mostly 2D. A module may support 2D. The package must stay usable in a 3D project: do not add a dependency on a 2D package, and do not assume every consumer uses sprites or 2D physics.

## Working on the package

Do not open this repository root as a Unity project. Unity would create `Assets/`, `ProjectSettings/`, and `Library/` beside `package.json`.

Use a separate Unity 6000.0 (or newer) project:

1. In Package Manager, choose **Add package from disk** and select this repo's `package.json`. Unity writes a `file:` dependency into that project's `Packages/manifest.json`.
2. To run this package's tests, add its name to `testables` in that manifest:

```json
{
  "dependencies": {
    "com.brickpad.protocatalog": "file:/absolute/path/to/Brickpad-Proto-Catalog"
  },
  "testables": [
    "com.brickpad.protocatalog"
  ]
}
```

3. Open **Window → General → Test Runner**. `Brickpad.ProtoCatalog.Editor.Tests` runs in Edit Mode. `Brickpad.ProtoCatalog.Tests` runs in Play Mode.

While you are editing, keep the disk package. Consumers install from the git URL in [README.md](README.md).

## How a module is organized

A module is one feature: a small gameplay system, a tool, or a piece of tech. Each module has its own folder and its own sub-namespace. Modules share the package assemblies so a project takes one reference. Do not add an asmdef per module unless a dependency has to stay optional for projects that do not use that module.

```
Runtime/<ModuleName>/
  README.md
  ...runtime scripts
Editor/<ModuleName>/
  ...editor scripts, when the module has any
Tests/Runtime/<ModuleName>/
  ...Play Mode tests
Tests/Editor/<ModuleName>/
  ...Edit Mode tests
Samples~/<ModuleName>/
  .sample.json
  README.md
  ...demo scene or example scripts
```

`<ModuleName>` is PascalCase and matches the namespace segment (`Health`, not `health` or `HealthSystemUtils`).

| Code | Namespace | Assembly |
| --- | --- | --- |
| `Runtime/<ModuleName>/` | `Brickpad.ProtoCatalog.<ModuleName>` | `Brickpad.ProtoCatalog` |
| `Editor/<ModuleName>/` | `Brickpad.ProtoCatalog.<ModuleName>.Editor` | `Brickpad.ProtoCatalog.Editor` |
| `Tests/Runtime/<ModuleName>/` | `Brickpad.ProtoCatalog.<ModuleName>.Tests` | `Brickpad.ProtoCatalog.Tests` |
| `Tests/Editor/<ModuleName>/` | `Brickpad.ProtoCatalog.<ModuleName>.Editor.Tests` | `Brickpad.ProtoCatalog.Editor.Tests` |

Both package asmdefs use the root namespace `Brickpad.ProtoCatalog`. Write the full module namespace in each file. Editor namespaces end in `.Editor`.

Package-wide types stay at the root of `Runtime/` or `Editor/` (`ProtoCatalogInfo`, `ProtoCatalogEditor`). They are not modules and they do not get a row in the README index.

The `Editor/` folder is only a convention. `includePlatforms: ["Editor"]` on `Brickpad.ProtoCatalog.Editor` is what keeps editor code out of players. Runtime scripts must not reference `UnityEditor`.

### When a module needs its own assembly

Stay on the shared assemblies. A per-module asmdef is an exception, for a dependency that projects which skip that module should not have to install. Name it `Brickpad.ProtoCatalog.<ModuleName>`, reference only what it uses, and explain the split in the module README and in the pull request before adding it.

## Module README

Every module has one README. Put it at `Runtime/<ModuleName>/README.md`. If the module is editor-only, put it at `Editor/<ModuleName>/README.md` instead. Do not keep a second copy.

```markdown
# Health

## What it does

Tracks a hit-point pool and raises events when the value changes. It does not spawn objects or know which scene it is in.

## Setup

1. Create a Health Config asset (Assets → Create → Brickpad → Health Config).
2. Add the Health component to a GameObject and assign the config.

## Dependencies

None. Unity 6 and Brickpad Proto-Catalog only.
```

If there is a dependency, name the package id and why (`com.unity.inputsystem` for rebinding, for example). A dependency of code in the shared assembly is also a dependency of `package.json`.

## Quality bar

A prototype is copied into this catalog only when every item below is true. Leave anything that fails in the game that grew it.

- [ ] **No scene-specific hardcoding.** No scene names, no `GameObject.Find` or `FindObjectOfType` for objects that belong to one game, and no hardcoded `Assets/...` paths from a project. The host project passes in what the module needs.
- [ ] **Configurable via ScriptableObjects or serialized fields.** Values a designer would tune, and references the module cannot invent, are serialized. Constants are only for real invariants.
- [ ] **No external dependencies unless declared.** The module builds with Unity 6 and this package alone, or every extra package is named in the module README and declared in `package.json` (or called out as an optional assembly, above). No copied third-party source without a license note.
- [ ] **XML doc comments on the public API.** Every public type and every public member has a `///` summary. Internal helpers can stay uncommented.
- [ ] **A sample or demo.** `Samples~/<ModuleName>/` shows how to use the module, and the sample is registered (see Samples).
- [ ] **Tests where sensible.** Rules, transitions, and parsing get tests. Skip a test that only sends a message through a MonoBehaviour with no logic of its own. Play Mode tests go under `Tests/Runtime/<ModuleName>/`. Edit Mode tests go under `Tests/Editor/<ModuleName>/`.
- [ ] **Right assembly.** Runtime code lives in `Runtime/<ModuleName>/` and does not reference editor APIs. Editor code lives in `Editor/<ModuleName>/`.
- [ ] **Does not make the catalog 2D-only.** 2D behaviour is fine when it is opt-in and documented. It must not add a 2D dependency that a 3D project cannot avoid.

## Promoting a module

1. Confirm the quality bar.
2. Add the folders, README, code, tests, and sample.
3. Register the sample in `package.json` and `.sample.json`.
4. Add a row to the module index in `README.md`. Replace the "no modules yet" row if it is still there.
5. Add an `[Unreleased]` note in `CHANGELOG.md`.
6. Leave the `package.json` version alone unless this change is the release.

## Samples

Register each sample in two places, with the same display name and description.

`package.json`:

```json
{
  "displayName": "Health",
  "description": "One sentence that says what the sample demonstrates.",
  "path": "Samples~/Health"
}
```

`Samples~/Health/.sample.json`:

```json
{
  "displayName": "Health",
  "description": "One sentence that says what the sample demonstrates."
}
```

The `Samples~` tilde is required. Unity does not compile that folder with the package. Package Manager copies it into the project when the sample is imported.

Ship `.meta` files inside the sample so scripts and scenes keep their GUIDs after import. Do not add `Samples~.meta` beside the folder. `.sample.json` is a dotfile and does not get a meta.

## Meta files

Unity skips an asset in an immutable package when its `.meta` is missing, and it warns. Every file the package imports needs a sibling `.meta` whose GUID is 32 lowercase hex characters.

- A folder meta sits beside the folder (`Runtime.meta` next to `Runtime/`) and sets `folderAsset: yes`.
- Scripts, asmdefs, markdown, and `package.json` each have their own `.meta`.
- Dotfiles (`.gitignore`, `.sample.json`) do not get a meta.
- A folder whose name ends in `~` is not imported with the package. Samples still ship metas so an imported sample keeps stable references.

Generate a GUID once and keep it. If you add files through a project that has this package from disk, Unity writes the metas; commit them. Do not change a GUID after a scene, prefab, or sample references it.

## Versioning

[Semantic Versioning](https://semver.org/spec/v2.0.0.html), recorded in `CHANGELOG.md` ([Keep a Changelog](https://keepachangelog.com/en/1.1.0/)).

| Bump | When |
| --- | --- |
| Patch | Bug fixes that do not change the public API. |
| Minor | A new module or other backwards-compatible change. |
| Major | A breaking change to the public API. |

While the major version is 0, a minor bump may include breaking changes. Say so in the changelog when it happens.

`package.json` `version` is the package version. Do not bump it on every module pull request. On a release:

1. Move the `[Unreleased]` notes into `## [X.Y.Z] - YYYY-MM-DD`.
2. Set `version` in `package.json` and `ProtoCatalogInfo.Version` to that number.
3. Tag the release commit on `main` as `vX.Y.Z`. Package Manager pins that tag with `#vX.Y.Z`.

## Style

Match the code already in the repo: UTF-8, LF line endings, 4-space indent, Allman braces, namespaces under `Brickpad.ProtoCatalog`. Public members get XML docs.
