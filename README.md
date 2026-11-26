# Brickpad Proto-Catalog

Brickpad Proto-Catalog is a Unity library of small gameplay systems, tools, and features. A piece of tech starts in a prototype. When it is stable and no longer tied to that one game, it is promoted here so another Unity project can install it.

The catalog targets Unity 6 (6000.0 and newer). The projects it comes from are mostly 2D. The package is not 2D-only: it does not depend on 2D physics, sprites, or a specific render pipeline. A module may support 2D, and it has to say so.

0.1.0 is the package shell. There are no gameplay modules yet. `ProtoCatalogInfo` reports the package version so tests and samples can prove the assembly reference. It is not a system to build a game on.

## Requirements

- Unity 6000.0 or newer

## Install

The package is at the repository root, so Package Manager takes the plain git URL. No `?path=` query.

Open **Window → Package Manager → + → Add package from git URL** and paste:

```
https://github.com/ExecutiveActual/Brickpad-Proto-Catalog.git
```

That follows the default branch. Pin the 0.1.0 release by appending the version tag:

```
https://github.com/ExecutiveActual/Brickpad-Proto-Catalog.git#v0.1.0
```

The same URLs work in `Packages/manifest.json`:

```json
{
  "dependencies": {
    "com.brickpad.protocatalog": "https://github.com/ExecutiveActual/Brickpad-Proto-Catalog.git#v0.1.0"
  }
}
```

Tags are `v` plus the `package.json` version (`v0.1.0`). Publish the tag from `main` when that version is released. Until the tag exists, omit the `#` fragment and follow the default branch.

## Module index

Promoted modules are listed here. Namespaces sit under `Brickpad.ProtoCatalog`.

| Module | Namespace | Summary | Dependencies |
| --- | --- | --- | --- |
| — | — | No modules have been promoted yet. | — |

Replace the placeholder row when the first module lands. Layout, the module README, and the quality bar are in [CONTRIBUTING.md](CONTRIBUTING.md).

## Samples

| Sample | What it is |
| --- | --- |
| Placeholder | Shows the sample layout and logs the catalog version. Not a gameplay module. |

Import it from this package's details in Package Manager. Then add the **Placeholder Sample** component to a GameObject and enter Play Mode.

## Layout

```
Runtime/                 Brickpad.ProtoCatalog
Editor/                  Brickpad.ProtoCatalog.Editor  (editor only)
Tests/Runtime/           Play Mode tests
Tests/Editor/            Edit Mode tests
Samples~/Placeholder/    Package Manager sample
```

## Versioning

This package uses [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

| Bump | When |
| --- | --- |
| Patch | Fixes that do not change the public API. |
| Minor | A new module, or another backwards-compatible addition. |
| Major | A breaking change to the public API. |

While the version is 0.y.z, a minor bump may include breaking changes. The changelog calls that out when it happens.

History lives in [CHANGELOG.md](CHANGELOG.md) ([Keep a Changelog](https://keepachangelog.com/en/1.1.0/)). `package.json` `version`, `ProtoCatalogInfo.Version`, and the git tag (without the `v`) are the same number.

## Tests

Tests ship inside the package and are excluded from player builds. To run them, add `com.brickpad.protocatalog` to `testables` in the Unity project's `Packages/manifest.json`, then open **Window → General → Test Runner**. Steps are in [CONTRIBUTING.md](CONTRIBUTING.md).

## License

[MIT](LICENSE.md). Copyright (c) 2026 Nicolas Lanza.
